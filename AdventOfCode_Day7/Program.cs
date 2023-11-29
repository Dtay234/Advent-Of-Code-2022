﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode_Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Directory> directories = new List<Directory>();
            List<Directory> path = new List<Directory>();

            //string input = "$ cd /\r\n$ ls\r\ndir grdd\r\n270251 hjlvwtph.jzv\r\n230026 jzmgcj.gmd\r\ndir nns\r\ndir rrfflbql\r\n$ cd grdd\r\n$ ls\r\n233044 mqbz.fcp\r\ndir nnch\r\n82939 rgtvsqsh.psq\r\n150253 srvg.dth\r\n$ cd nnch\r\n$ ls\r\n4014 mqbz.fcp\r\n$ cd ..\r\n$ cd ..\r\n$ cd nns\r\n$ ls\r\ndir cgbdghtd\r\ndir dnh\r\ndir gjhp\r\ndir jwjm\r\ndir mrpfzd\r\ndir ncvv\r\ndir pfnglqgw\r\ndir tlh\r\ndir vnrhpc\r\n$ cd cgbdghtd\r\n$ ls\r\n276941 jrrcdgz.szm\r\n$ cd ..\r\n$ cd dnh\r\n$ ls\r\n269539 nnch\r\n220637 sjzmpwwb\r\n$ cd ..\r\n$ cd gjhp\r\n$ ls\r\ndir czclvmwc\r\ndir jgtzfsm\r\n$ cd czclvmwc\r\n$ ls\r\n179729 fzqvvlg\r\n67916 pmsdthr.prv\r\n$ cd ..\r\n$ cd jgtzfsm\r\n$ ls\r\n151591 rcggj.nwm\r\n$ cd ..\r\n$ cd ..\r\n$ cd jwjm\r\n$ ls\r\n203559 nnch\r\n$ cd ..\r\n$ cd mrpfzd\r\n$ ls\r\ndir pfnglqgw\r\n204978 qscs.vpq\r\n16184 tbfwpmp.hvl\r\n$ cd pfnglqgw\r\n$ ls\r\ndir wvzw\r\ndir ztl\r\n$ cd wvzw\r\n$ ls\r\n195912 jpn.ndh\r\n143238 nnch.djz\r\n2239 pmsdthr.prv\r\ndir sfqq\r\n$ cd sfqq\r\n$ ls\r\n134913 pthmqd\r\ndir vcdhz\r\n$ cd vcdhz\r\n$ ls\r\n13800 ffhv.jnq\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ztl\r\n$ ls\r\n181007 mqbz.fcp\r\n266517 zbpjz.gbr\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\n296494 ccmvjm.bjb\r\n20801 hjr\r\n32494 mqbz.fcp\r\ndir nnch\r\ndir pfnglqgw\r\ndir qpq\r\ndir rftzzmq\r\ndir wgblcl\r\n294511 wrdmgdb.fmh\r\n$ cd nnch\r\n$ ls\r\ndir hjzpfvm\r\ndir ncvv\r\ndir pffr\r\ndir pfnglqgw\r\ndir ssdffgsq\r\n$ cd hjzpfvm\r\n$ ls\r\n304078 mqbz.fcp\r\ndir nnch\r\n146425 nnch.lrw\r\ndir vcfglm\r\ndir zhscvh\r\n$ cd nnch\r\n$ ls\r\n311625 gqmpvplj.vjg\r\n248744 ndfcj\r\n$ cd ..\r\n$ cd vcfglm\r\n$ ls\r\ndir btptvs\r\ndir ghpvzvzp\r\n146354 nnch\r\n$ cd btptvs\r\n$ ls\r\n127157 nqnnwq.rtz\r\n16115 pmsdthr.prv\r\n$ cd ..\r\n$ cd ghpvzvzp\r\n$ ls\r\ndir ncvv\r\n$ cd ncvv\r\n$ ls\r\n236869 pmsdthr.prv\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd zhscvh\r\n$ ls\r\n225337 glpz\r\n$ cd ..\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\ndir nljtcssr\r\ndir svjhsvjh\r\n$ cd nljtcssr\r\n$ ls\r\n258085 gqmpvplj.vjg\r\ndir ncvv\r\ndir qmzfgcr\r\n249049 wznr.gbs\r\ndir zvvpqlmq\r\n$ cd ncvv\r\n$ ls\r\n147686 ndfcj.sfr\r\n$ cd ..\r\n$ cd qmzfgcr\r\n$ ls\r\n162245 ndfcj.nlj\r\n$ cd ..\r\n$ cd zvvpqlmq\r\n$ ls\r\n160481 ggnc\r\n$ cd ..\r\n$ cd ..\r\n$ cd svjhsvjh\r\n$ ls\r\ndir bjqbmt\r\n58138 gqmpvplj.vjg\r\ndir nsvf\r\n154398 rrhjs.gch\r\ndir wmvhmlr\r\n$ cd bjqbmt\r\n$ ls\r\n252614 ndfcj.wzg\r\n153886 nnch\r\n214625 zhmdvb\r\n$ cd ..\r\n$ cd nsvf\r\n$ ls\r\n274932 nnch.jfg\r\n$ cd ..\r\n$ cd wmvhmlr\r\n$ ls\r\n137205 nnch\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pffr\r\n$ ls\r\n89895 cwpnzngf.swg\r\n197833 jgv\r\n184768 jjhzddp.fbb\r\n31033 tpngfdsg.brv\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\n228015 ccmvjm.bjb\r\n$ cd ..\r\n$ cd ssdffgsq\r\n$ ls\r\n165887 gqmpvplj.vjg\r\ndir lfq\r\ndir nnch\r\n170828 qjb.mnp\r\ndir ttj\r\n$ cd lfq\r\n$ ls\r\n257411 gqmpvplj.vjg\r\n137375 jzmgcj.gmd\r\n267329 nsbsgd.zvq\r\n$ cd ..\r\n$ cd nnch\r\n$ ls\r\ndir mrfwfq\r\n171186 ndhqthf.jlp\r\n$ cd mrfwfq\r\n$ ls\r\n100447 lsfsh.mvr\r\n$ cd ..\r\n$ cd ..\r\n$ cd ttj\r\n$ ls\r\n49634 ndfcj\r\ndir tqvld\r\n$ cd tqvld\r\n$ ls\r\ndir ndfcj\r\n$ cd ndfcj\r\n$ ls\r\ndir gnzj\r\n80690 pmlnbvj\r\n12843 zbrfmfgj.lzr\r\n$ cd gnzj\r\n$ ls\r\ndir wtpzrpn\r\n$ cd wtpzrpn\r\n$ ls\r\n33840 gqmpvplj.vjg\r\n18122 rrfflbql.vws\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\n289092 fdjfvb\r\n$ cd ..\r\n$ cd qpq\r\n$ ls\r\n126281 ccmvjm.bjb\r\ndir crtzrd\r\n231988 jzmgcj.gmd\r\n203061 mgmmp\r\n272098 mqbz.fcp\r\ndir pfnglqgw\r\ndir qzvcsn\r\n105003 rrfflbql.mcm\r\n$ cd crtzrd\r\n$ ls\r\n162336 fsps\r\n100215 mctd.wsz\r\n67983 mqbz.fcp\r\n281538 mqq.cgz\r\ndir ndfcj\r\ndir rrfflbql\r\ndir wbmtvr\r\n$ cd ndfcj\r\n$ ls\r\n290647 pfjczr.wjc\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\ndir mpr\r\ndir ncvv\r\ndir rrfflbql\r\n301818 zml.qfj\r\n$ cd mpr\r\n$ ls\r\n237300 gqmpvplj.vjg\r\ndir pfnglqgw\r\n$ cd pfnglqgw\r\n$ ls\r\ndir brnwdjtg\r\ndir dvqlmzw\r\n248787 pmsdthr.prv\r\n$ cd brnwdjtg\r\n$ ls\r\n256129 ncvv\r\ndir ptztp\r\n$ cd ptztp\r\n$ ls\r\n104775 nnch.wlc\r\n$ cd ..\r\n$ cd ..\r\n$ cd dvqlmzw\r\n$ ls\r\n25407 twgqbrtl\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\ndir jvwvsm\r\n62293 jzmgcj.gmd\r\n261836 mqbz.fcp\r\ndir vvvrf\r\n$ cd jvwvsm\r\n$ ls\r\n222978 ccmvjm.bjb\r\n207799 jzmgcj.gmd\r\ndir pcvsvcn\r\n248569 pmsdthr.prv\r\ndir wmd\r\n$ cd pcvsvcn\r\n$ ls\r\n39803 pmsdthr.prv\r\n$ cd ..\r\n$ cd wmd\r\n$ ls\r\n9516 rfstbvj.nhz\r\n$ cd ..\r\n$ cd ..\r\n$ cd vvvrf\r\n$ ls\r\ndir ncvv\r\ndir znwc\r\n$ cd ncvv\r\n$ ls\r\n110667 jzmgcj.gmd\r\n$ cd ..\r\n$ cd znwc\r\n$ ls\r\n182248 ndfcj.crv\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\n231013 ccmvjm.bjb\r\ndir jlc\r\ndir rrfflbql\r\n79210 ttm.zmw\r\n$ cd jlc\r\n$ ls\r\n28096 ccmvjm.bjb\r\n113156 pmsdthr.prv\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\n234558 lbg.bpn\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd wbmtvr\r\n$ ls\r\n285832 fqhs\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\n110965 nnch\r\n195414 pmsdthr.prv\r\n243812 thcpw.jfw\r\n$ cd ..\r\n$ cd qzvcsn\r\n$ ls\r\n279179 gqmpvplj.vjg\r\n191705 mhmlfc.czv\r\n146298 pfnglqgw.ppm\r\n2775 pmsdthr.prv\r\n$ cd ..\r\n$ cd ..\r\n$ cd rftzzmq\r\n$ ls\r\n310418 bddhlvs.rwm\r\n152681 cdznrjl\r\n278447 rrfflbql\r\ndir tmcltf\r\n$ cd tmcltf\r\n$ ls\r\ndir mzr\r\n$ cd mzr\r\n$ ls\r\n24154 ccmvjm.bjb\r\ndir nnch\r\ndir rqsbw\r\n$ cd nnch\r\n$ ls\r\n100523 mqbz.fcp\r\n$ cd ..\r\n$ cd rqsbw\r\n$ ls\r\n64033 czzqg.pcz\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd wgblcl\r\n$ ls\r\n235768 dvdzbgv.vwl\r\n186757 jzmgcj.gmd\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\n129407 zfphqcsf.cfn\r\n$ cd ..\r\n$ cd tlh\r\n$ ls\r\n89310 jzmgcj.gmd\r\n21486 nwnbbmr.lsq\r\n40023 rdmtp.zsf\r\n$ cd ..\r\n$ cd vnrhpc\r\n$ ls\r\n104731 gqmpvplj.vjg\r\n176015 grn\r\n3646 jzmgcj.gmd\r\ndir ncvv\r\n45414 nfrj.lvq\r\n233767 pfnglqgw.bvf\r\n$ cd ncvv\r\n$ ls\r\n252691 ccmvjm.bjb\r\ndir ncvv\r\ndir vwv\r\ndir wwmwfbf\r\n$ cd ncvv\r\n$ ls\r\n306441 qfhhnmqz.snc\r\n$ cd ..\r\n$ cd vwv\r\n$ ls\r\n56033 rrfflbql\r\n$ cd ..\r\n$ cd wwmwfbf\r\n$ ls\r\n45964 gqmpvplj.vjg\r\n118391 mvwl\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\n175540 bcw.sqp\r\n154750 ggncvs.nvn\r\ndir jqzm\r\ndir mgbglnr\r\n192820 ndfcj\r\ndir pfnglqgw\r\n217147 qjng.svz\r\ndir rrfflbql\r\n$ cd jqzm\r\n$ ls\r\ndir ncvv\r\ndir nfcvcddz\r\n242934 rjwlgm\r\ndir wzj\r\n$ cd ncvv\r\n$ ls\r\n298067 pfnglqgw.jdv\r\n$ cd ..\r\n$ cd nfcvcddz\r\n$ ls\r\n261264 gqmpvplj.vjg\r\n19464 mqbz.fcp\r\n121507 ncqhrf\r\ndir ndfcj\r\n58485 ndfcj.vhh\r\ndir rcrzjm\r\n228359 wnftnshq\r\n$ cd ndfcj\r\n$ ls\r\n309008 bwn\r\n$ cd ..\r\n$ cd rcrzjm\r\n$ ls\r\n48178 fgzpwhvt\r\n129342 qns.lnj\r\n$ cd ..\r\n$ cd ..\r\n$ cd wzj\r\n$ ls\r\n91384 gqmpvplj.vjg\r\ndir nnch\r\ndir rzm\r\n$ cd nnch\r\n$ ls\r\ndir sgbwrl\r\n$ cd sgbwrl\r\n$ ls\r\ndir ndfcj\r\n$ cd ndfcj\r\n$ ls\r\n295624 cbmdr\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd rzm\r\n$ ls\r\ndir cprj\r\n86746 dfwsj.hqq\r\ndir dljnvq\r\ndir ndfcj\r\n159465 nsglq\r\n202670 pfnglqgw.wbh\r\n29700 rrfflbql.wln\r\ndir vgtftq\r\n$ cd cprj\r\n$ ls\r\n148192 gqmpvplj.vjg\r\n165473 hwp.ltc\r\n$ cd ..\r\n$ cd dljnvq\r\n$ ls\r\n91675 pmsdthr.prv\r\n$ cd ..\r\n$ cd ndfcj\r\n$ ls\r\n83124 rrfflbql.ghs\r\n$ cd ..\r\n$ cd vgtftq\r\n$ ls\r\n186744 mqbz.fcp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd mgbglnr\r\n$ ls\r\ndir ddtcz\r\ndir ncvv\r\ndir nhpwf\r\ndir rrfflbql\r\n203683 ttbc\r\ndir tvbjgv\r\ndir wvzcq\r\n$ cd ddtcz\r\n$ ls\r\n61553 wfzj\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\n37589 ccmvjm.bjb\r\n87987 dnct\r\n196537 ndfcj.cqg\r\n40448 pmsdthr.prv\r\n$ cd ..\r\n$ cd nhpwf\r\n$ ls\r\n243345 gqmpvplj.vjg\r\n53165 nnch.gfc\r\ndir pfnglqgw\r\ndir vdnnf\r\n$ cd pfnglqgw\r\n$ ls\r\n131411 mhvzv.scz\r\n142119 nnch.gnt\r\n$ cd ..\r\n$ cd vdnnf\r\n$ ls\r\n83904 ccmvjm.bjb\r\ndir czfqdtd\r\ndir dgblftbz\r\ndir jnftbbtm\r\ndir pfbnl\r\ndir pfnglqgw\r\n$ cd czfqdtd\r\n$ ls\r\ndir nnch\r\n$ cd nnch\r\n$ ls\r\n255744 ndfcj.ldv\r\n$ cd ..\r\n$ cd ..\r\n$ cd dgblftbz\r\n$ ls\r\n278883 ncvv.zph\r\ndir pfnglqgw\r\n133315 phns.cmq\r\n130316 sftj\r\n$ cd pfnglqgw\r\n$ ls\r\n174155 vnwtv\r\n$ cd ..\r\n$ cd ..\r\n$ cd jnftbbtm\r\n$ ls\r\n255828 nmln\r\n30605 pfnglqgw\r\n$ cd ..\r\n$ cd pfbnl\r\n$ ls\r\n8603 ndfcj\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\n235364 pmsdthr.prv\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\ndir gfgbj\r\n$ cd gfgbj\r\n$ ls\r\n215226 jzmgcj.gmd\r\n$ cd ..\r\n$ cd ..\r\n$ cd tvbjgv\r\n$ ls\r\ndir nnch\r\n$ cd nnch\r\n$ ls\r\ndir gmsb\r\n$ cd gmsb\r\n$ ls\r\ndir tlqdvpr\r\n$ cd tlqdvpr\r\n$ ls\r\n130013 hzrq.zrg\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd wvzcq\r\n$ ls\r\ndir ncvv\r\n$ cd ncvv\r\n$ ls\r\n103168 ccmvjm.bjb\r\n18537 ncvv\r\ndir nnch\r\ndir rrfflbql\r\n$ cd nnch\r\n$ ls\r\n20928 ndfcj.lln\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\ndir lgfwf\r\n$ cd lgfwf\r\n$ ls\r\ndir fmzqt\r\ndir rrfflbql\r\n$ cd fmzqt\r\n$ ls\r\n301419 gqmpvplj.vjg\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\ndir nbvqch\r\n$ cd nbvqch\r\n$ ls\r\n298966 csqvdql.cwr\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\ndir bhmndjpq\r\n203077 fssbcjcm.hvt\r\ndir lfslp\r\ndir ncvv\r\ndir nftdcrl\r\ndir nnch\r\ndir pfnglqgw\r\ndir qfbbnr\r\ndir wttc\r\n$ cd bhmndjpq\r\n$ ls\r\n299744 cmgwwccb.tvv\r\n173562 fpwv\r\ndir hmnbfdtr\r\ndir jqpcs\r\n73425 mqbz.fcp\r\ndir ncvv\r\ndir ndfcj\r\n95707 pmsdthr.prv\r\ndir ptzdv\r\ndir qzhrsnqh\r\ndir sbqg\r\n$ cd hmnbfdtr\r\n$ ls\r\ndir pfnglqgw\r\ndir qmpplbtv\r\n77228 tvpdstcn.zbb\r\n$ cd pfnglqgw\r\n$ ls\r\ndir dwr\r\ndir jmgp\r\n102634 mqbz.fcp\r\n148654 ncvv\r\n257637 ncvv.nzn\r\n286938 rrfflbql\r\n$ cd dwr\r\n$ ls\r\n141669 ndfcj\r\n9012 ptrlq.stq\r\n$ cd ..\r\n$ cd jmgp\r\n$ ls\r\n78473 pfnglqgw\r\n$ cd ..\r\n$ cd ..\r\n$ cd qmpplbtv\r\n$ ls\r\n202948 wjp.rgt\r\n$ cd ..\r\n$ cd ..\r\n$ cd jqpcs\r\n$ ls\r\n290654 fmmcph\r\n8123 zrr.vqm\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\ndir hbrttp\r\n$ cd hbrttp\r\n$ ls\r\n128004 nffzj\r\n$ cd ..\r\n$ cd ..\r\n$ cd ndfcj\r\n$ ls\r\ndir vscwfsl\r\n$ cd vscwfsl\r\n$ ls\r\n251706 snww.dzb\r\n$ cd ..\r\n$ cd ..\r\n$ cd ptzdv\r\n$ ls\r\n113702 nnch\r\n$ cd ..\r\n$ cd qzhrsnqh\r\n$ ls\r\n118758 gqmpvplj.vjg\r\n75504 vcnn.stz\r\n102737 zvv\r\n$ cd ..\r\n$ cd sbqg\r\n$ ls\r\n287663 bhcpslm.wwt\r\ndir bqr\r\ndir czhfphh\r\n39170 fqn\r\ndir gqnts\r\n267314 hlv.ljc\r\n8701 jqpdpg.prz\r\ndir ncvv\r\n211749 psln.pdq\r\n$ cd bqr\r\n$ ls\r\ndir chjfw\r\ndir dgccfvtl\r\n219440 fvfsfz\r\n262276 jzmgcj.gmd\r\ndir ndfcj\r\n294287 pfnglqgw.lwh\r\n163881 rrfflbql\r\n278231 vgjm.rrh\r\n$ cd chjfw\r\n$ ls\r\n134800 hvmvqbz.bqj\r\n$ cd ..\r\n$ cd dgccfvtl\r\n$ ls\r\n155579 lwmqrd.wvp\r\n$ cd ..\r\n$ cd ndfcj\r\n$ ls\r\n144255 ncvv.hrn\r\n236730 ndfcj\r\ndir pfz\r\n$ cd pfz\r\n$ ls\r\n297448 rrfflbql.fdt\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd czhfphh\r\n$ ls\r\ndir wmws\r\n$ cd wmws\r\n$ ls\r\n14499 ncvv\r\n$ cd ..\r\n$ cd ..\r\n$ cd gqnts\r\n$ ls\r\n165940 ccmvjm.bjb\r\ndir gjcm\r\ndir hldzdlrl\r\ndir jtnpgg\r\ndir nnch\r\n287896 pmsdthr.prv\r\n$ cd gjcm\r\n$ ls\r\n125716 gqmpvplj.vjg\r\ndir mhjm\r\n197155 msspbg\r\n176407 trtdggnf\r\n$ cd mhjm\r\n$ ls\r\n18749 jzmgcj.gmd\r\n252999 nnch\r\n76392 rrfflbql.mzh\r\n$ cd ..\r\n$ cd ..\r\n$ cd hldzdlrl\r\n$ ls\r\ndir gzpcgj\r\ndir rvvgn\r\n$ cd gzpcgj\r\n$ ls\r\ndir vfz\r\n$ cd vfz\r\n$ ls\r\n183852 pmsdthr.prv\r\n$ cd ..\r\n$ cd ..\r\n$ cd rvvgn\r\n$ ls\r\n143443 ndfcj\r\n$ cd ..\r\n$ cd ..\r\n$ cd jtnpgg\r\n$ ls\r\ndir dhvd\r\ndir hlmgslbs\r\ndir rrfflbql\r\ndir vmqpcm\r\n$ cd dhvd\r\n$ ls\r\n131598 ltr.rph\r\n$ cd ..\r\n$ cd hlmgslbs\r\n$ ls\r\n173562 rrfflbql\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\ndir ghvmc\r\n$ cd ghvmc\r\n$ ls\r\n311611 jzmgcj.gmd\r\n$ cd ..\r\n$ cd ..\r\n$ cd vmqpcm\r\n$ ls\r\n192032 mqbz.fcp\r\n$ cd ..\r\n$ cd ..\r\n$ cd nnch\r\n$ ls\r\n112995 ccmvjm.bjb\r\n$ cd ..\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\n106711 dswpw.wgr\r\n46614 jzmgcj.gmd\r\n115391 mqbz.fcp\r\ndir nnch\r\n61970 pmsdthr.prv\r\ndir rrfflbql\r\n$ cd nnch\r\n$ ls\r\n50060 gqjtv.gcs\r\ndir lnmmd\r\n73078 ncvv\r\n49129 tfb\r\ndir vgwpcjrl\r\ndir wnqlrqlf\r\n$ cd lnmmd\r\n$ ls\r\n71780 gqmpvplj.vjg\r\n$ cd ..\r\n$ cd vgwpcjrl\r\n$ ls\r\n8269 zcspgw\r\n$ cd ..\r\n$ cd wnqlrqlf\r\n$ ls\r\ndir wzsvhssb\r\n$ cd wzsvhssb\r\n$ ls\r\n187249 jzmgcj.gmd\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\ndir bpzmvds\r\n24889 hfnbzcn\r\ndir lqffwfr\r\n274793 nnch.svh\r\ndir rhwm\r\n$ cd bpzmvds\r\n$ ls\r\n298048 tfnqwpj\r\n$ cd ..\r\n$ cd lqffwfr\r\n$ ls\r\ndir mzfpbjtl\r\n$ cd mzfpbjtl\r\n$ ls\r\n217469 jzmgcj.gmd\r\n$ cd ..\r\n$ cd ..\r\n$ cd rhwm\r\n$ ls\r\n54198 gqmpvplj.vjg\r\ndir tlnmwhdt\r\n$ cd tlnmwhdt\r\n$ ls\r\n94380 ndfcj.bvv\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd lfslp\r\n$ ls\r\ndir cmrwvp\r\ndir cnh\r\n311549 jgmf.fbs\r\ndir jtgrbqvj\r\n166298 pbwsqpcg.whf\r\n151437 pfnglqgw.mcj\r\ndir sqlwn\r\n$ cd cmrwvp\r\n$ ls\r\n217666 pmsdthr.prv\r\n172469 vzw.rqw\r\n$ cd ..\r\n$ cd cnh\r\n$ ls\r\n84011 jfb.mpt\r\n$ cd ..\r\n$ cd jtgrbqvj\r\n$ ls\r\ndir dcfpfq\r\ndir ghhs\r\ndir ntbmh\r\ndir pfnglqgw\r\n$ cd dcfpfq\r\n$ ls\r\n159731 pfnglqgw\r\n$ cd ..\r\n$ cd ghhs\r\n$ ls\r\n104713 blwnhcn\r\n$ cd ..\r\n$ cd ntbmh\r\n$ ls\r\n174007 jzmgcj.gmd\r\ndir pfnglqgw\r\n60549 rrfflbql.scj\r\ndir zwcdggd\r\n$ cd pfnglqgw\r\n$ ls\r\n49844 rfdw.pqh\r\n$ cd ..\r\n$ cd zwcdggd\r\n$ ls\r\n135925 ccmvjm.bjb\r\n1135 gqmpvplj.vjg\r\n120968 hmgpcj.nbb\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\n184937 ccmvjm.bjb\r\n128621 llsjsmg.vtv\r\ndir lsbf\r\n42834 ndfcj.fwq\r\n85391 trrchml.sgp\r\n$ cd lsbf\r\n$ ls\r\n192593 cfdtsfq.sln\r\n289191 nnch.qzj\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd sqlwn\r\n$ ls\r\n77962 ccmvjm.bjb\r\n114288 ndfcj\r\n$ cd ..\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\ndir gsd\r\n$ cd gsd\r\n$ ls\r\n14949 jwcp.lmq\r\n$ cd ..\r\n$ cd ..\r\n$ cd nftdcrl\r\n$ ls\r\n185409 jzmgcj.gmd\r\n$ cd ..\r\n$ cd nnch\r\n$ ls\r\n280827 djftt\r\ndir ljt\r\ndir ncvv\r\ndir ndfcj\r\n33396 qvhndl.pwn\r\n136204 qvlc.cbr\r\n14063 rrfflbql.mrq\r\n130666 vscjncbm.sls\r\n$ cd ljt\r\n$ ls\r\n166514 cgrgbpvw\r\n55138 jzmgcj.gmd\r\n$ cd ..\r\n$ cd ncvv\r\n$ ls\r\ndir fhnw\r\n56003 gqtcgszl.vnf\r\n145831 jzmgcj.gmd\r\ndir mwcbd\r\ndir rclnhb\r\n$ cd fhnw\r\n$ ls\r\n28050 gqmpvplj.vjg\r\n$ cd ..\r\n$ cd mwcbd\r\n$ ls\r\n288468 ncvv\r\n$ cd ..\r\n$ cd rclnhb\r\n$ ls\r\n190004 ndjmjbp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ndfcj\r\n$ ls\r\n287125 gqmpvplj.vjg\r\ndir ndfcj\r\n247237 nnch\r\n138902 pfnglqgw\r\n$ cd ndfcj\r\n$ ls\r\n143400 ssvsvffz\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfnglqgw\r\n$ ls\r\ndir cwwb\r\ndir dtf\r\n97867 mqbz.fcp\r\n$ cd cwwb\r\n$ ls\r\ndir wtz\r\n$ cd wtz\r\n$ ls\r\n300949 zcq\r\n$ cd ..\r\n$ cd ..\r\n$ cd dtf\r\n$ ls\r\n28018 gqmpvplj.vjg\r\n$ cd ..\r\n$ cd ..\r\n$ cd qfbbnr\r\n$ ls\r\ndir bqmdfjp\r\n89207 gjfzv\r\n176709 pmsdthr.prv\r\n246390 rrfflbql.vdl\r\n$ cd bqmdfjp\r\n$ ls\r\n137504 cwz.jdg\r\n9191 ncvv\r\n$ cd ..\r\n$ cd ..\r\n$ cd wttc\r\n$ ls\r\n279516 ccmvjm.bjb\r\n115478 lwnpwdqt.jpj\r\n$ cd ..\r\n$ cd ..\r\n$ cd rrfflbql\r\n$ ls\r\n162371 nnch.pnm";
            //File.WriteAllText("textfile.txt", input);
            string[] lines = File.ReadAllLines("textfile.txt");

            //path.Add(new Directory("/"));
            bool list = false;
            Directory currentDirectory;
            
            


            foreach (string line in lines)
            {
                Console.WriteLine(line);
                if (line[0] == '$')
                {                    
                    if (line.Substring(2, 2) == "cd")
                    {
                        if (line.Substring(5) == "..")
                        {
                            path.Remove(path.Last());

                            currentDirectory = path.Last();
                            
                        }

                        else
                        {
                            /*
                            if (path.Count != 0)
                            {
                                foreach (Item item in path.Last().items)
                                {
                                    if (item.name == line.Substring(5) && item is Directory)
                                    {
                                        contains = true;
                                        path.Add((Directory)item);

                                        currentDirectory = path.Last();
                                    }

                                }

                                if (!contains)
                                {
                                    Directory newThing = new Directory(line.Substring(5));
                                    path.Last().items.Add(newThing);
                                    path.Add(newThing);
                                    currentDirectory = path.Last();
                                }
                            }
                            else
                            {
                                Directory newThing = new Directory(line.Substring(5));
                                path.Add(newThing);
                                //path.Last().items.Add(newThing);
                                
                            }
                            */

                            Directory newThing = new Directory(line.Substring(5));
                            path.Add(newThing);
                            directories.Add(newThing);
                                
                            
                        }



                    }
                    else if (line.Substring(2, 2) == "ls")
                    {
                        list = true;
                    }
                }
                else
                {
                    if (line.Substring(0, 3) == "dir" )
                    {
                        Directory thing = new Directory(line.Substring(4));
                        path.Last().items.Add(thing);

                        //bool contains = false;

                        //foreach (Directory directory in directories)
                        //{
                        //    if (thing.name == directory.name)
                        //    {
                        //        contains = true;
                        //    }
                        //}

                        //if (!contains) { directories.Add(thing); }
                    }
                    else
                    {
                        int firstSpace = line.IndexOf(' ');
                        int size = int.Parse(line.Substring(0, firstSpace));
                        string name = line.Substring(firstSpace + 1);
                        path.Last().items.Add(new OtherFile(size, name));
                    }
                    
                }

            }


            List<long> sizes = new List<long>();
            int count = 0;

            //while (count < 3)
            //{
            //    sizes.Add(TotalSize(path[0]));

            //    Console.WriteLine(sizes[count]);

            //    count++;
            //}
            //foreach ()

            
            //Console.WriteLine(TotalSize(path[0], sizes));

            //foreach (Directory directory in directories)
            //{
            //    sizes.Add(TotalSize(directory, sizes));
            //}

            long total = 0;

            //foreach (long l in sizes)
            //{
            //    if (l < 100000)
            //    {
            //        sizes.Remove(l);
            //        total += l;
            //    }
            //}

            foreach (Directory directory in directories)
            {
                if (directory.Size < 100000)
                {
                    Console.WriteLine(directory.name + ": " + directory.Size);
                    total += directory.Size;
                }
            }

            Console.WriteLine(total);


        }

        public static long TotalSize(Directory directory, List<long> sizes)
        {

            long sum = 0;
            

            foreach (Item item in directory.items)
            {


                if (item is OtherFile)
                {
                    sum += ((OtherFile)item).size;

                }
                else if (item is Directory) 
                {
                    sum += TotalSize((Directory)item, sizes);   
                    
                }

                sizes.Add(sum);
            }

            return sum;
            
        }

        
       
    }
}